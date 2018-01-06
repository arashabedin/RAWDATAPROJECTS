import { Component, Inject, NgModule, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Routes, ActivatedRoute } from '@angular/router';
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
    public question: GetQuestion[];
   // public sampleData: any;

    url = 'api/question/' + this.route.snapshot.paramMap.get('id');
    
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {

        http.get(baseUrl + this.url).subscribe(result => {
            this.question = result.json() as GetQuestion[];
         //   this.sampleData = result.json().commentsUrl;
        }, error => console.error(error));

    }

ngOnInit() {

}

}

interface GetQuestion {
    commentsUrl: string
}
