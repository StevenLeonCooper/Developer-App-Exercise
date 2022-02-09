import { Model } from '../modules/model.js';

export class Student extends Model {
    constructor() {
        super({ apiUrl: "api/student" });

    }
}