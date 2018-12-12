import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { getBaseUrl } from '../main';

@Injectable()
export class ListsService {
  private headers: HttpHeaders;
  public accessPointUrl: string;

  constructor(private http: HttpClient,@Inject('BASE_URL') baseUrl: string) {
    this.accessPointUrl = baseUrl;
    this.headers = new HttpHeaders({ 'Content-Type': 'application/json; charset=utf-8' });
  }

  public get() {
    // Get all list data
    return this.http.get<Lists[]>(this.accessPointUrl + 'api/lists');
  }

  public add(payload) {
    return this.http.post(this.accessPointUrl, payload, { headers: this.headers });
  }
}

interface Lists {
  id: number;
  name: string;
  //tasks: Tasks[];
}
