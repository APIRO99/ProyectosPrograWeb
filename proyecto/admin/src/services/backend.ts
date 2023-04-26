
const API_URL = "http://localhost:5182";
const buildHeaders = (authToken: string) => ({
  "Content-Type": "application/json",
  "Authorization": `Bearer ${authToken}`
});


// ==============================|| USERS ||============================== //

export const GetUsers = async (authToken: string): Promise<IGetUsersResponse> => {
  var response = await fetch(`${API_URL}/users`, {
    method: "GET",
    headers: buildHeaders(authToken),
  });
  return await response.json();
}

export const GetUser = async (authToken: string, id: string): Promise<IGetUserResponse> => {
  var response = await fetch(`${API_URL}/users/${id}`, {
    method: "GET",
    headers: buildHeaders(authToken),
  });
  return await response.json();
}

export const CreateUser = async (authToken: string, user: IUser): Promise<ICreateUserResponse> => {
  const body: any = {
    name: user.name,
    username: user.username,
    email: user.email,
    password: user.password
  }
  var response = await fetch(`${API_URL}/users`, {
    method: "POST",
    headers: buildHeaders(authToken),
    body: JSON.stringify(body),
  });
  return await response.json();
}

export const UpdateUser = async (authToken: string, user: IUser): Promise<IUpdateUserResponse> => {
  var response = await fetch(`${API_URL}/users`, {
    method: "PUT",
    headers: buildHeaders(authToken),
    body: JSON.stringify(user),
  });
  return await response.json();
}

export const DeleteUser = async (authToken: string, id: string): Promise<IDeleteUserResponse> => {
  var response = await fetch(`${API_URL}/users/${id}`, {
    method: "DELETE",
    headers: buildHeaders(authToken),
  });
  return await response.json();
}


// ==============================|| PROPERTIES ||============================== //

export const GetProperties = async (authToken: string): Promise<IGetPropertiesResponse> => {
  var response = await fetch(`${API_URL}/properties`, {
    method: "GET",
    headers: buildHeaders(authToken),
  });
  return await response.json();
}

export const GetProperty = async (authToken: string, id: string): Promise<IGetPropertyResponse> => {
  var response = await fetch(`${API_URL}/properties/${id}`, {
    method: "GET",
    headers: buildHeaders(authToken),
  });
  return await response.json();
}

export const CreateProperty = async (authToken: string, property: IProperty): Promise<ICreatePropertyResponse> => {
  const body: any = {
    name: property.name,
    address: property.address,
    city: property.city,
    state: property.state,
    photo: property.photo,
    status: property.status,
    beds: property.beds,
    baths: property.baths,
    weekRent: property.weekRent,
    model: property.model,
  }
  var response = await fetch(`${API_URL}/properties`, {
    method: "POST",
    headers: buildHeaders(authToken),
    body: JSON.stringify(body),
  });
  return await response.json();
}

export const UpdateProperty = async (authToken: string, property: IProperty): Promise<IUpdatePropertyResponse> => {
  var response = await fetch(`${API_URL}/properties`, {
    method: "PUT",
    headers: buildHeaders(authToken),
    body: JSON.stringify(property),
  });
  return await response.json();
}

export const DeleteProperty = async (authToken: string, id: number): Promise<IDeletePropertyResponse> => {
  var response = await fetch(`${API_URL}/properties/${id}`, {
    method: "DELETE",
    headers: buildHeaders(authToken),
  });
  return await response.json();
}


// ==============================|| FILES ||============================== //

export const SaveImage = async (file: File): Promise<ISaveImageResponse> => {
  const formData = new FormData();
  formData.append("file", file);
  var response = await fetch(`${API_URL}/files/images`, {
    method: "POST",
    body: formData,
  });
  return await response.json();
}