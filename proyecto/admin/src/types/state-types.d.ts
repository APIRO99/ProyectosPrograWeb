export {};

declare global {
	/**
   * Now declare things that go in the global namespace,
   * or augment existing declarations in the global namespace.
   */
	interface IState {
		session: ISession | null;
	}

	interface ISession {
		user: string;
		name: string;
		token: string;
	}
}
