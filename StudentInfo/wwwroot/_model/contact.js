import { Model } from '../modules/model.js';

export class Contact extends Model {
    constructor() {
        super({ apiUrl: "api/contact" });
    }

    byStudent(studentId) {
        this.apiUrl = `api/contact/sid/${studentId}`
    }
}