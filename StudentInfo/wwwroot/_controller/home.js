import { Controller } from '../modules/controller.js';
import { View, Partial } from '../modules/view.js';
import { Student } from '../_model/student.js';
import { Contact } from '../_model/contact.js';


const studentModel = new Student();
const homeView = new View("home");
const homeController = new Controller(homeView, studentModel);

(async () => {

    await homeController.setup();

    let data = homeController.model.export();

    window.test = data;

    homeController.view.render(data);

})();

homeController.onClick("getContacts", (e) => {

    let source = e.target;
    let studentId = source.dataset.studentId;
    let contacts = new Contact(studentId);
    let contactsPartial = new Partial("Contacts");

    (async () => {

        await contacts.import();

        let data = contacts.export();

        contactsPartial.render(data);

    })();

});