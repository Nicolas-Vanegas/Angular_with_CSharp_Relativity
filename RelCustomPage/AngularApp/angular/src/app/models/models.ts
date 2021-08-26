export class Doc {
    position?: number;
    controlNumber?: string;
}
export class DictionaryAndDocId {
    artifactId?: number;
    dictionaryObjects?: DictionaryObjects[];
  }
  
  export class DictionaryObjects {
    word?: string;
    origin?: string;
    meanings?: Meanings[];
    phonetics?: Phonetics[];
  }
  
  export class Phonetics {
    audio?: string;
  }
  
  export class Meanings {
    definitions?: Definitions[];
  }
  
  export class Definitions {
    definition?: string;
  }