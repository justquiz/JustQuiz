import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private _httpService: HttpClient) { }

  emotions: object[] = [];
  error: any;

  ngOnInit(): void {
    this._httpService.get('/api/Emotions/GetEmotions')
      .subscribe((data: object[]) => this.emotions = [...data], // success path
                  error => this.error = error); // error path
  }

  title = 'MyMind';
}
