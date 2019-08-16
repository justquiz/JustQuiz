import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  constructor(private _httpService: HttpClient) { }

  emotions: string[] = [];

  ngOnInit(): void {
    this._httpService.get('localhost:22077/api/Emotions/GetEmotions').subscribe(values => {
      this.emotions = JSON.parse(values as string);
    });
  }

  title = 'MyMind';
}
