import { createAction, props } from '@ngrx/store';

export const saveSelectedDocumentId = createAction(
    '[Datapoints] save selected document id',
    props<{ documentId: number }>()
  );