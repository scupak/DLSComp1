import { Component } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public httpClient: HttpClient;
  public baseUrl: string = "http://localhost:9000";
  public searchResult?: SearchResult = undefined;
  public searchTerms: string = "";


  constructor(http: HttpClient) {
    this.httpClient = http;
  }

  public search(searchTerms: string) {
    this.httpClient.get<SearchResult>(this.baseUrl + '/Search?terms=' + searchTerms + "&numberOfResults=" + 10).subscribe(result => {
      this.searchResult = result;
      console.log(result);
    }, error => console.error(error));
  }

}

interface SearchResult {
  ellapsedMiliseconds: number;
  ignoredTerms: string[];
  documents: Document[];

}

interface Document {

  id: bigint;
  path: string;
  numberOfAppearances: bigint;

}
