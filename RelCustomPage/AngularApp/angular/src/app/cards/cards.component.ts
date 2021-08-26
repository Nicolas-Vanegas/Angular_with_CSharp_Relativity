import { Component, Input, OnInit } from '@angular/core';
import { DictionaryService  } from '../services/dictionary.service';
import { DictionaryAndDocId, DictionaryObjects, Phonetics, Meanings, Definitions } from "../models/models";
import { select, Store } from '@ngrx/store';
import * as documentsReducer from '../reducer/documents.reducer';
import { Observable } from 'rxjs';


export class Word {
  word?: string;
  meaning?: string;
  origin?: string;
  audio?: string;
}

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})

export class CardsComponent implements OnInit {

  selectedDocumentId$?: Observable<number>;
  selectedDocumentId?: number;
  dictionary: DictionaryAndDocId[] = [];
  words?: Word[] = [];
  dictionaryObjects?: DictionaryObjects[] = [];
  phonetics?: Phonetics[] = [];
  meanings?: Meanings [] = [];
  definitions?: Definitions[] = [];
  workspaceId = 1017767;

  constructor(private dictionaryService : DictionaryService, private store: Store<{selectedDocument: number}>) {  }

  ngOnInit() {
    this.selectedDocumentId$ = this.store.pipe(select(documentsReducer.getSelectedDocumentId));
    this.printCards();
  }

  printCards() {
    this.selectedDocumentId$ = this.store.pipe(select(documentsReducer.getSelectedDocumentId));
    this.selectedDocumentId$.subscribe(x => {
      this.selectedDocumentId = x;
    });
    if(this.dictionary.length <= 0){
      this.dictionaryService.GetDictionary(this.workspaceId).subscribe((x: DictionaryAndDocId[]) => {
        this.words = [];
        this.fillDictionary(x);
        this.fillCard();
      })
    }
    else {
      this.fillCard();
    }
  }

  fillDictionary(dictionaryAndDocId: DictionaryAndDocId[]) {
    dictionaryAndDocId.forEach(dictionary => {
      this.dictionary.push({artifactId: dictionary.artifactId, dictionaryObjects: dictionary.dictionaryObjects})
    });
  }
  
  fillCard() {
    this.words = [];
    this.dictionary.forEach(dictionary => {
      if (dictionary.artifactId === this.selectedDocumentId)
        {
          var theWord: string | undefined;
          var theOrigin: string | undefined;
          var theDefinition: string | undefined;
          var theAudio: string | undefined;
          this.dictionaryObjects = dictionary.dictionaryObjects;
          this.dictionaryObjects?.forEach(dic => {
            theWord = dic.word;
            theOrigin = dic.origin;
            this.meanings = dic.meanings;
            this.phonetics = dic.phonetics;
            this.phonetics?.forEach(phonetic => {
              theAudio = phonetic.audio
            });
            this.meanings?.forEach(meaning => {
              this.definitions = meaning.definitions;
              this.definitions?.forEach(definition => {
                theDefinition = `${definition.definition}`
              });
            });
          });
          this.words?.push({word: theWord, meaning: theDefinition, origin: theOrigin, audio: theAudio})
        }
      });
  }
}
