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

    console.log("activated");

    let source = e.target;
    let studentId = source.dataset.studentId;
    let contacts = new Contact().byStudent(studentId);
    let contactsPartial = new Partial("contact", {
        selector: `#StudentContacts_${studentId}`
    });

    (async () => {

        await contacts.import();

        await contactsPartial.import();

        let data = contacts.export();

        contactsPartial.render(data);

    })();

});