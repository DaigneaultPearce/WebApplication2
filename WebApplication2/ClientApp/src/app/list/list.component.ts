import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ListsService } from '../lists.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html'
})
export class ListComponent {
  public lists: Lists[];
  public taskss: Tasks[];
  public listss: Lists[];

  constructor(listsService: ListsService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Tasks[]>(baseUrl + 'api/tasks').subscribe(result => {
      this.taskss = result;
    }, error => console.error(error));

    listsService.get().subscribe(result => {
      this.listss = result;
    }, error => console.error(error))
  }
  
}

interface Lists {
  id: number;
  name: string;
  //tasks: Tasks[];
}

interface Tasks {

  id: number;
  listid: number;
  desc: string;
}
