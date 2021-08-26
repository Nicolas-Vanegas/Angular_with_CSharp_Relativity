import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TableComponent } from './table/table.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from '@angular/material/table';
import { HttpClientModule } from '@angular/common/http';
import { DocumentService } from './services/document.service';
import { CardsComponent } from './cards/cards.component';
import {MatCardModule} from '@angular/material/card';
import { NgxAudioPlayerModule } from 'ngx-audio-player';
import { DictionaryService } from './services/dictionary.service';
@NgModule({
  declarations: [
    AppComponent,
    TableComponent,
    CardsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatCardModule,
    HttpClientModule,
    NgxAudioPlayerModule
  ],
  providers: [DocumentService, DictionaryService],
  bootstrap: [AppComponent]
})
export class AppModule { }
