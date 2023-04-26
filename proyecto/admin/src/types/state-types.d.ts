export {};

declare global {
	/**
   * Now declare things that go in the global namespace,
   * or augment existing declarations in the global namespace.
   */
	interface IState {s
		session: ISession | null;
	}

	interface ISession {
		username: string;
		name: string;
		email: string;
		token: string;
	}

	interface ILoginData {
		username: string;
		password: string;
		keepSesion: boolean;
	}

	interface IUser {
		id: string,
    name: string,
    username: string,
    email: string,
    password: string,
    created_at: Date,
	}

	interface IProperty {
		id?: int,
		name: string,
		address: string,
		city: string,
		state: string,
		photo: string,
		status: string,
		beds: int,
		baths: int,
		weekRent: int,
		model: string,
	}
}
