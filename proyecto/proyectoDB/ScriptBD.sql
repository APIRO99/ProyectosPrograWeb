

CREATE TABLE properties (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    address VARCHAR(255) NOT NULL,
    city VARCHAR(255) NOT NULL,
    state VARCHAR(255) NOT NULL,
    photo VARCHAR(255) NOT NULL,
    status VARCHAR(50) NOT NULL
);

CREATE TABLE users (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO properties (name, address, city, state, photo, status) VALUES 
('Luxury Condo with Ocean View', '1234 Main Street', 'Miami', 'Florida', 'https://images.unsplash.com/photo-1564013799919-ab600027ffc6?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8YmVhdXRpZnVsJTIwaG91c2V8ZW58MHx8MHx8&w=1000&q=80', 'Active'),
('Spacious Townhouse near Downtown', '5678 Elm Street', 'San Francisco', 'California', 'https://images.familyhomeplans.com/cdn-cgi/image/fit=scale-down,quality=85/plans/44207/44207-b600.jpg', 'Inactive'),
('Cozy Cottage in the Woods', '910 Pine Avenue', 'Seattle', 'Washington', 'https://images.familyhomeplans.com/cdn-cgi/image/fit=scale-down,quality=85/plans/44207/44207-b600.jpg', 'Active'),
('Modern Apartment with City View', '1111 Broadway', 'New York', 'New York', 'https://images.familyhomeplans.com/cdn-cgi/image/fit=scale-down,quality=85/plans/81310/81310-b580.jpg', 'Inactive'),
('Charming Bungalow in Historic District', '2222 Maple Street', 'Charleston', 'South Carolina', 'https://assets-news.housing.com/news/wp-content/uploads/2022/03/31010142/Luxury-house-design-Top-10-tips-to-add-luxury-to-your-house-FEATURE-compressed.jpg', 'Active');



INSERT INTO users (name, email, password, created_at) VALUES 
('John Smith', 'john.smith@example.com', 'password123', NOW()),
('Emily Nguyen', 'emily.nguyen@example.com', 'p@ssword456', NOW()),
('Michael Johnson', 'michael.johnson@example.com', 'qwerty123', NOW()),
('Ava Patel', 'ava.patel@example.com', 'mypassword', NOW()),
('David Kim', 'david.kim@example.com', 'hello123', NOW());

