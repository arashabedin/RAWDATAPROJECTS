import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Routes, ActivatedRoute, Router, NavigationEnd} from '@angular/router';
import { CommentsComponent } from '../comments/comments.component';
import { AnswersComponent } from '../answers/answers.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
@NgModule({
    declarations: [QuestionComponent, CommentsComponent],
    bootstrap: [QuestionComponent]
})

@Component({
    selector: 'question',
    templateUrl: './question.component.html',

})

export class QuestionComponent implements OnInit{
    questionReady: boolean = false;
    public question: GetQuestion[];
   // public sampleData: any;

    url = 'api/question/' + this.route.snapshot.paramMap.get('id');
    newId:number = 0;
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {

        http.get(baseUrl + this.url).subscribe(result => {
            this.question = result.json() as GetQuestion[];
         //   this.sampleData = result.json().commentsUrl;
        }, error => console.error(error));


        router.events
            .subscribe((event) => {

                if (event instanceof NavigationEnd) {
                    http.get(baseUrl + this.url
                    ).subscribe(result => {

                        this.question = result.json() as GetQuestion[];
                        this.questionReady = true;

                        }, error => console.error(error));
                }

            });

    }

ngOnInit() {

    }



    public goToQuestion(id: number) {
        //this.router.navigate(['']);
        this.router.navigate(['/question', id]);
        this.url = 'api/question/' + id;

}


    public markThis() {
        var AddMarkingUrl = "/api/marking/" + this.route.snapshot.paramMap.get('id');
        var body = "";
        this.http
            .post(AddMarkingUrl,
            body)
            .subscribe(data => {

                this.http.get(this.baseUrl + this.url
                ).subscribe(result => {
                    this.question = result.json() as GetQuestion[];
                    }, error => console.error(error));

            }, error => {
                console.log(JSON.stringify(error.json()));
            });


    }

    public unMarkThis() {
        var deleteMarkingUrl = "/api/marking/" + this.route.snapshot.paramMap.get('id');
        var body = "";
        this.http
            .delete(deleteMarkingUrl,
            body)
            .subscribe(data => {
                this.http.get(this.baseUrl + this.url
                ).subscribe(result => {
                    this.question = result.json() as GetQuestion[];
                }, error => console.error(error));

            }, error => {
                console.log(JSON.stringify(error.json()));
            });


    }


}

 
interface GetQuestion {
    commentsUrl: string
}
