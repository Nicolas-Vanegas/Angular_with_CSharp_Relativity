import { Component, Input, OnInit } from '@angular/core';
import { DictionaryService  } from '../services/dictionary.service';
import { DictionaryAndDocId, DictionaryObjects, Phonetics, Meanings, Definitions } from "../models/models";


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

  @Input() selectedDocumentId?: number;

  dictionary: DictionaryAndDocId[] = [];
  words?: Word[] = [];
  dictionaryObjects?: DictionaryObjects[] = [];
  phonetics?: Phonetics[] = [];
  meanings?: Meanings [] = [];
  definitions?: Definitions[] = []; 

  workspaceId = 1017767;

  constructor(private dictionaryService : DictionaryService) {  }

  ngOnInit() {
    this.printCards(this.selectedDocumentId);
  }

  printCards(selectedDocumentId?:number) {
    this.dictionaryService.GetDictionary(this.workspaceId).subscribe((x: DictionaryAndDocId[]) => {
      this.words = [];
      this.fillCard(x, selectedDocumentId);
    })
  }

  fillCard(dictionaryAndDocId: DictionaryAndDocId[], selectedDocumentId?: number) {
    this.dictionary = [];
    dictionaryAndDocId.forEach(dictionary => {
        this.dictionary.push({artifactId: dictionary.artifactId, dictionaryObjects: dictionary.dictionaryObjects})
    });
    console.log(this.dictionary);
    this.dictionary.forEach(dictionary => {
      if (dictionary.artifactId === selectedDocumentId)
        {
          var theWord: string | undefined;
          var theOrigin: string | undefined;
          var theDefinition: string | undefined;
          var theAudio: string | undefined;
          this.dictionaryObjects = dictionary.dictionaryObjects;
          console.log(this.dictionaryObjects);
          this.dictionaryObjects?.forEach(dic => {
            theWord = dic.word;
            theOrigin = dic.word;
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
          console.log(this.meanings);
          console.log(this.definitions);
          console.log(this.phonetics);
          this.words?.push({word: theWord, meaning: theDefinition, origin: theOrigin, audio: theAudio})
          console.log(this.words);
        }
      });
  }
}
