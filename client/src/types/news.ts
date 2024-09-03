interface Translation {
    id: string;
    languageId: string;
    title: string;
    content: string;
  }
  
  interface Tag {
    id: string;
    name: string;
  }
  
  interface News {
    id: string;
    imagePath: string;
    publicationDate: string;
    author: string;
    sourceLink: string;
    sharedById: string;
    translations: Translation[];
    tags: Tag[];
  }