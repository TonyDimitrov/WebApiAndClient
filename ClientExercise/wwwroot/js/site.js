function deleteBtn() {

    let buttons = document.getElementsByClassName('btn-delete');

    [...buttons].forEach(b => b.addEventListener('click', deleteItem))
}

async function deleteItem(event) {

    let btn = event.target;
    let id = btn.getAttribute('data-id');

    let lastSlashIndex = btn.baseURI.lastIndexOf('/');
    let baseUrl = btn.baseURI.substring(0, lastSlashIndex + 1);
    let fullUrl = baseUrl + 'delete/' + id

    const httpMethod = "GET";

    const headers = {
        method: httpMethod,
        headers: {
            "Content-Type": "application/json"
        }
    };

    await fetch(fullUrl, headers)
        .then(handleError)
        .then(serializeData);

    function handleError(e) {
        if (!e.ok) {
            throw new Error(e.statusText);
        }

        return e;
    }

    function serializeData(x) {
        if (x.status === 200) {
            window.location.reload();
        }
    }

}

deleteBtn();