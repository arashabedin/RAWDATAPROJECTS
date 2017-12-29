import { Component, Inject } from '@angular/core';
import { NgModule } from '@angular/core';
import { Http } from '@angular/http';
import { Routes } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';


//npm install --save jquery
//npm install - D @types/jquery

@Component({
    selector: 'comments',
    templateUrl: './comments.component.html'
})
export class CommentsComponent {
    public comments: GetComments[];

    url = "api/question/19/comment";

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {

        http.get(baseUrl + this.url).subscribe(result => {
            this.comments = result.json() as GetComments[];
        }, error => console.error(error));

    }


}

interface GetComments {
}

