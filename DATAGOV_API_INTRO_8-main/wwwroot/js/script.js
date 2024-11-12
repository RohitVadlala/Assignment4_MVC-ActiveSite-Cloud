// Sample Data for other sections, if any
const destinationForm = document.getElementById('destinationForm');
const destinationsList = document.getElementById('destinationsList');

// Initialize destinations array if empty
let destinations = [
    { id: 1, name: 'Paris', country: 'France', price: 1200, description: 'City of Love' },
    { id: 2, name: 'Rome', country: 'Italy', price: 1100, description: 'Eternal City' }
];

// Define emergingDestinations array
let emergingDestinations = [
    { id: 1, name: 'Berlin', country: 'Germany', popularity: 800 },
    { id: 2, name: 'Lisbon', country: 'Portugal', popularity: 900 }
];


// Function to handle scroll and active link updates
function initializeScrollNav() {
    const navLinks = document.querySelectorAll('.navbar a');

    function updateActiveLink() {
        const sections = document.querySelectorAll('section');
        let current = '';

        sections.forEach(section => {
            const sectionTop = section.offsetTop;
            if (window.scrollY >= sectionTop - 200) {
                current = section.getAttribute('id');
            }
        });

        navLinks.forEach(link => {
            link.classList.remove('active');
            if (link.getAttribute('href').slice(1) === current) {
                link.classList.add('active');
            }
        });
    }

    window.addEventListener('scroll', updateActiveLink);

    navLinks.forEach(link => {
        link.addEventListener('click', function () {
            navLinks.forEach(link => link.classList.remove('active'));
            this.classList.add('active');
        });
    });
}



// CRUD Operations

// Add new destination
function addDestination(e) {
    e.preventDefault();
    const newDest = {
        id: destinations.length + 1,
        name: document.getElementById('destName').value,
        country: document.getElementById('destCountry').value,
        price: parseFloat(document.getElementById('destPrice').value),
        description: document.getElementById('destDescription').value
    };
    destinations.push(newDest);
    renderDestinations();
    destinationForm.reset();
}

// Add new booking
function addBooking(e) {
    e.preventDefault();
    const newBooking = {
        id: bookings.length + 1,
        destination: document.getElementById('bookingDestination').value,
        date: document.getElementById('bookingDate').value,
        travelers: parseInt(document.getElementById('travelers').value),
        status: 'Pending'
    };
    bookings.push(newBooking);
    renderBookings();
    e.target.reset();
}

// Render destinations
function renderDestinations() {
    const container = document.getElementById('destinationsList');
    if (container) {
        container.innerHTML = destinations.map(dest => `
            <div class="box" data-id="${dest.id}">
                <img src="/api/placeholder/400/300" alt="${dest.name}">
                <h3>${dest.name}, ${dest.country}</h3>
                <p>${dest.description}</p>
                <div class="price">€${dest.price}</div>
                <div class="icons">
                    <a href="#" onclick="editDestination(${dest.id})" class="fas fa-edit"></a>
                    <a href="#" onclick="deleteDestination(${dest.id})" class="fas fa-trash"></a>
                </div>
            </div>
        `).join('');
    }
}

// Edit destination
function editDestination(id) {
    const dest = destinations.find(d => d.id === id);
    if (dest) {
        document.getElementById('destName').value = dest.name;
        document.getElementById('destCountry').value = dest.country;
        document.getElementById('destPrice').value = dest.price;
        document.getElementById('destDescription').value = dest.description;

        const submitBtn = destinationForm.querySelector('button');
        submitBtn.textContent = 'Update Destination';
        destinationForm.setAttribute('data-edit-id', id);

        destinationForm.removeEventListener('submit', addDestination);
        destinationForm.addEventListener('submit', updateDestination);
    }
}

// Update destination
function updateDestination(e) {
    e.preventDefault();
    const id = parseInt(destinationForm.getAttribute('data-edit-id'));
    const index = destinations.findIndex(d => d.id === id);

    if (index !== -1) {
        destinations[index] = {
            id: id,
            name: document.getElementById('destName').value,
            country: document.getElementById('destCountry').value,
            price: parseFloat(document.getElementById('destPrice').value),
            description: document.getElementById('destDescription').value
        };

        renderDestinations();
        destinationForm.reset();

        const submitBtn = destinationForm.querySelector('button');
        submitBtn.textContent = 'Add Destination';
        destinationForm.removeAttribute('data-edit-id');
        destinationForm.removeEventListener('submit', updateDestination);
        destinationForm.addEventListener('submit', addDestination);
    }
}

// Delete destination
function deleteDestination(id) {
    if (confirm('Are you sure you want to delete this destination?')) {
        destinations = destinations.filter(d => d.id !== id);
        renderDestinations();
    }
}

// Render bookings
function renderBookings() {
    const tbody = document.getElementById('bookingsTableBody');
    if (tbody) {
        tbody.innerHTML = bookings.map(booking => `
            <tr>
                <td>${booking.destination}</td>
                <td>${booking.date}</td>
                <td>${booking.travelers}</td>
                <td>${booking.status}</td>
            </tr>
        `).join('');
    }
}

// Initialize all scripts on page load
document.addEventListener('DOMContentLoaded', function () {
    initializeScrollNav();
    renderDestinations();
    renderBookings();
    if (destinationForm) {
        destinationForm.addEventListener('submit', addDestination);
    }
});
