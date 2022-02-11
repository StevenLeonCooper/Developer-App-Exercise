import { Controller } from '../modules/controller.js';
import { EventData } from '../modules/events.js';
import { View, Partial } from '../modules/view.js';
import { Student } from '../_model/student.js';
import { Contact } from '../_model/contact.js';


const studentModel = new Student();
const homeView = new View("home", { css: true });
const homeController = new Controller(homeView, studentModel);

(async () => {

    await homeController.setup();

    let data = homeController.model.export();

    window.test = data;

    homeController.view.render(data);

})();

homeController.onClick("getContacts", (e) => {

    let eData = new EventData(e);

    let studentId = eData.studentId;

    let state = eData.state;

    function toggleText(eData) {
        
        let newText = eData.element.dataset.altText;

        eData.element.dataset.altText = eData.element.innerText;

        eData.element.innerText = newText;
    }

    let action = {
        new: () => {
            let contacts = new Contact().byStudent(studentId);

            let contactsPartial = new Partial("contact", {
                selector: `#StudentContacts_${studentId}`
            });

            (async () => {

                await contacts.import();

                await contactsPartial.import();

                let data = contacts.export();

                contactsPartial.render(data);

                eData.element.dataset.state = "open";

                toggleText(eData);

            })();
        },
        open: () => {
            
            eData.targetElement.classList.toggle("no-display");

            eData.element.dataset.state = "closed";

            toggleText(eData);
        },

        closed: () => {

            eData.targetElement.classList.toggle("no-display");

            eData.element.dataset.state = "open";

            toggleText(eData);
        }
    }

    action[state]();



});