import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ListsService } from '../lists.service';
import { List } from '../list';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html'
})
export class ListComponent {
  public lists: List[];
  public taskss: Tasks[];

  constructor(private listsService: ListsService, private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Tasks[]>(baseUrl + 'api/tasks').subscribe(result => {
      this.taskss = result;
    }, error => console.error(error));

    listsService.get().subscribe(result => {
      this.lists = result;
    }, error => console.error(error))
  }

  getTasks(@Inject('BASE_URL') baseUrl: string) {

    return this.http.get<Tasks[]>(baseUrl + 'api/tasks');
  }
  add(id: number,name: string): void {
    name = name.trim();
    if (!name) { return; }
    this.listsService.add({ id, name } as List)
      .subscribe(list => {
        this.lists.push(list);
      });
  }
}



interface Tasks {

  id: number;
  listid: number;
  desc: string;
}
