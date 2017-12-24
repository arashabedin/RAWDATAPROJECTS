import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
    selector: 'questions',
    templateUrl: './questions.component.html'
})
export class QuestionsComponent {
    public questions: GetQuestions[];

    url = 'api/question?page=' + this.route.snapshot.paramMap.get('page')+ "&pageSize=12";
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {
        http.get(baseUrl + this.url).subscribe(result => {
            this.questions = result.json() as GetQuestions[];
        }, error => console.error(error));
    }
   


    public goTopage(url: string) {
        this.url = url;
        this.http.get(url).subscribe(result => {
            this.questions = result.json() as GetQuestions[];
        }, error => console.error(error));
     }
    public goToQuestion(id:number) {

        this.router.navigate(['/question', id]);
        
    }


}


interface GetQuestions {
}
