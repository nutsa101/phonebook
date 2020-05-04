import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ServiceResponse } from '../models/service-response';
import { SearchResponse } from '../models/search-response';
import { PhoneBookEntry } from '../models/phone-book-entry';

@Injectable({
  providedIn: 'root'
})

export class PhoneBookService {

  constructor(public http: HttpClient) {
    this.baseUrl = environment.apiBaseUrl;
  }

  private baseUrl: string;

  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': '3033d814-096d-41ad-9756-1651181392c7'
    })
  }; // hardcoded the id token to identify the user| no time to implementation authentication

  getEntries(name: string): Observable<ServiceResponse<SearchResponse>> {
    const url = this.baseUrl + 'phoneBook?name=' + name;
    return this.http.get<ServiceResponse<SearchResponse>>(url, this.httpOptions);
  }

  savEntries(phoneBookEntry: PhoneBookEntry): Observable<ServiceResponse<PhoneBookEntry>> {
    const url = this.baseUrl + 'phoneBook';
    return this.http.post<ServiceResponse<PhoneBookEntry>>(url, phoneBookEntry, this.httpOptions);
  }

}
