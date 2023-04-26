export { };

declare global {
  /**
   * Now declare things that go in the global namespace,
   * or augment existing declarations in the global namespace.
   */
  interface ILoginResponse {
    token: string;
    expiration: Date;
    name: string;
    email: string;
  }

  // ==============================|| USERS ||============================== //

  interface IGetUsersResponse extends Array<IUser> { }

  interface IGetUserResponse extends IUser { }

  interface ICreateUserResponse extends IUser { }

  interface IUpdateUserResponse extends IUser { }

  interface IDeleteUserResponse extends IUser { }

  // ==============================|| PROPERTIES ||============================== //

  interface IGetPropertiesResponse extends Array<IProperty> { }

  interface IGetPropertyResponse extends IProperty { }

  interface ICreatePropertyResponse extends IProperty { }

  interface IUpdatePropertyResponse extends IProperty { }

  interface IDeletePropertyResponse extends IProperty { }

  
  // ==============================|| IMAGES ||============================== //

  interface ISaveImageResponse {
    filename: string;
  }

}
