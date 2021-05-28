export type TodoType = {
  id: string;
  done: boolean;
  content: string;
};

// OR

export interface TodoModel {
  id: string;
  done: boolean;
  content: string;
}
