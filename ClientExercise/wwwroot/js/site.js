class CarsOperations {

    constructor() {
        this.btn;
    }

    deleteBtn() {
        let buttons = document.getElementsByClassName('btn-delete');

        [...buttons].forEach(b => b.addEventListener('click', (event) => this.deleteItem(event)));
    }

    async deleteItem(event) {

        this.btn = event.target;
        let id = this.btn.getAttribute('data-id');

        let lastSlashIndex = this.btn.baseURI.lastIndexOf('/');
        let baseUrl = this.btn.baseURI.substring(0, lastSlashIndex + 1);
        let fullUrl = baseUrl + 'delete/' + id;

        const httpMethod = "GET";

        const headers = {
            method: httpMethod,
            headers: {
                "Content-Type": "application/json"
            }
        };

        await fetch(fullUrl, headers)
            .then(e => {
                if (!e.ok) {
                    throw new Error(e.statusText);
                }

                return e;
            })
            .then(e => this.deleteRow(e, this.btn));
    }

    deleteRow(e, btn) {
        if (e.status === 200) {
            let test = btn;
            let row = btn.parentElement.parentElement;
            row.hidden = true;
        }
        return e;
    }

    editBtn() {

        let buttons = document.getElementsByClassName('btn-edit');

        [...buttons].forEach(b => b.addEventListener('click', (event) => this.editItem(event)));
    }

    async editItem(event) {

        this.btn = event.target;
        let id = this.btn.getAttribute('data-id');

        let lastSlashIndex = this.btn.baseURI.lastIndexOf('/');
        let baseUrl = this.btn.baseURI.substring(0, lastSlashIndex + 1);
        let fullUrl = baseUrl + 'GetById/' + id;

        const httpMethod = "GET";

        const headers = {
            method: httpMethod,
            headers: {
                "Content-Type": "application/json"
            }
        };

        await fetch(fullUrl, headers)
            .then(r => {

                if (!r.ok) {
                    throw new Error(r.statusText);
                }

                return r;
            })
            .then(r => this.serializeData(r))
            .then(r => this.trigerEditModal(r));
    }

    serializeData(r) {
        if (r.status === 204) {
            return x;
        }
        if (r.status === 404) {
            let element = document.getElementById('error-div');

            let op = 1;  // initial opacity
            let timer = setInterval(function () {
                if (op <= 0.1) {
                    clearInterval(timer);
                    element.style.display = 'none';
                }
                element.style.opacity = op;
                element.style.filter = 'alpha(opacity=' + op * 100 + ")";
                op -= op * 0.1;
            }, 50);
        }
        return r.json();
    }

    trigerEditModal(r) {
        document.getElementById("car-id-edit").value = r.id;
        document.getElementById("car-brand-edit").value = r.brand;
        document.getElementById("car-year-edit").value = r.yearOfProduction.slice(0, 10);;

        let editModalForm = document.getElementById('edit-modal');
        editModalForm.hidden = false;
    }
}

let operations = new CarsOperations();
operations.deleteBtn();
operations.editBtn();