import { Component, Inject } from '@angular/core';
import { NgModule } from '@angular/core';
import { Http } from '@angular/http';
import { Routes } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { CommentsComponent } from '../comments/comments.component';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';



@Component({
    selector: 'question',
    templateUrl: './question.component.html',
    
})

export class QuestionComponent {
    public question: GetQuestion[];

    url = 'api/question/' + this.route.snapshot.paramMap.get('id');
    
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {

        http.get(baseUrl + this.url).subscribe(result => {
            this.question = result.json() as GetQuestion[];
        }, error => console.error(error));
    }


    }

interface GetQuestion {
}
