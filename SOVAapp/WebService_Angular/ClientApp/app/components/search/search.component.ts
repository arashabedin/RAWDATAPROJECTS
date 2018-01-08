import { Component, Inject,Input,OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { ActivatedRoute, Router, NavigationEnd } from '@angular/router';

@Component({
    selector: 'search',
    templateUrl: './search.component.html'
})
export class SearchComponent implements OnInit {
    public searches: GetSearches;
    public searchHistory : GetSearchHistory;
    Url = this.route.snapshot.queryParams["url"];
    newPageUrl: string;
    searchText: string ='';
    isSearching: boolean = false;
    isSearched: boolean = false;
    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute, private router: Router) {



     

        router.events
            .subscribe((event) => {
              
                    if (event instanceof NavigationEnd) {
                        this.searches = {};
                        this.isSearching = true;
                        var pageNumber = this.route.snapshot.queryParams["page"];
                        if (pageNumber == null) {
                            this.isSearching = false;
                        }
                        var text = this.searchText;
                        http.get(this.baseUrl + 'api/search/'+text+'?page=' + pageNumber + "&pageSize=12"
                    ).subscribe(result => {
                        this.isSearching = false;
                        this.searches = result.json() as GetSearches;
                        }, error => console.error(error));
                    }
                
                

            });

    }

    ngOnInit() {
        this.http.get(this.baseUrl + 'api/searchhistory'
        ).subscribe(result => {
            this.searchHistory = result.json() as GetSearchHistory;
        }, error => console.error(error));
    }

    startSearching() {
        this.isSearched = true;
        this.isSearching = true;
        this.router.navigate(['/search'], { queryParams: { searchText: this.searchText, page: 0 } });

    }
   searchItAgain(text: string) {
            this.isSearched = true;
            this.isSearching = true;
            this.searchText = text;
            this.router.navigate(['/search'], { queryParams: { searchText: text, page: 0 } });

    }
    goToPrev(url: string, pageNum: number) {
        this.isSearching = true;
        this.router.navigate(['/search'], { queryParams: { searchText: this.searchText, page: pageNum - 1 } });
        this.newPageUrl = url;
        
}
    goToNext(url: string, pageNum: number) {
        this.isSearching = true;
        this.router.navigate(['/search'], { queryParams: { searchText: this.searchText, page: pageNum + 1 } });
        this.newPageUrl = url;

    
    }


    public goToQuestion(id: number) {
        this.router.navigate(['/question', id]);
    }

    body: string = "";

}

interface GetSearches {
}

interface GetSearchHistory {
}
