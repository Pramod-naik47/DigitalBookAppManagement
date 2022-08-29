export interface VBookPayment {
    bookId: number;
    bookTitle: string;
    category: string;
    price: number;
    content: string;
    active: boolean;
    createdDate: Date
    publishDate: Date
    publisher: string;
    paymentId: number;
    email: string;
    paymentDate: Date
}