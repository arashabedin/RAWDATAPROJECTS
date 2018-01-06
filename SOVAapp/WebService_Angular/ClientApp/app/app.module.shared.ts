import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { QuestionsComponent } from './components/questions/questions.component';
import { QuestionComponent } from './components/question/question.component';
import { CommentsComponent } from './components/comments/comments.component';
import { AnswersComponent } from './components/answers/answers.component';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        QuestionComponent,
        QuestionsComponent,
        HomeComponent,
        CommentsComponent,
        AnswersComponent

    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'question/:id', component: QuestionComponent },
            { path: 'questions', component: QuestionsComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared {
}
