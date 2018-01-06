import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';

@Component({
    selector: 'questions',
    templateUrl: './questions.component.html'
})
export class QuestionsComponent {
    public questions: GetQuestions;

    url = 'api/question?page=' + this.route.snapshot.queryParams["page"] + "&pageSize=12";
    markingStatus: string;




    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {
        http.get(baseUrl + this.url).subscribe(result => {
            this.questions = result.json() as GetQuestions;
        }, error => console.error(error));

        router.events
            .subscribe((event) => {

                if (event instanceof NavigationEnd) {
                    var pageNumber = this.route.snapshot.queryParams["page"];
                    console.log(pageNumber);
                    http.get(baseUrl + 'api/question?page=' + pageNumber + "&pageSize=12"
                    ).subscribe(result => {
                        this.questions = result.json() as GetQuestions;
                    }, error => console.error(error));
                }

            });

    }



    public goToNextPage(url: string, pageNum: number) {
        this.url = url;
        this.router.navigate(['/questions'], { queryParams: { page: pageNum + 1 } });
    }

    public goToPrevPage(url: string, pageNum: number) {
        this.url = url;
        this.router.navigate(['/questions'], { queryParams: { page: pageNum - 1 } });
    }

    public goToQuestion(id: number) {
        this.router.navigate(['/question', id]);
    }

    body: string = "";

}

interface GetQuestions {
    page: number;
}

