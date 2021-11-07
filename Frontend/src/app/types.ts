export interface Author {
    id: number,
    firstName: string,
    lastName: string,
    createdUtc: Date,
    modifiedUtc: Date
}

export interface Book {
    id: number,
    title: string,
    description: string,
    genre: number,
    authorId: number,
    author?: Author
    createdUtc: Date,
    modifiedUtc: Date
}

export interface Genre {
    key: number,
    value: string
}

export interface BookDialogData {
    book?: Book;
    genres: Genre[];
    authors: Author[];
}