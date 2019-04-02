interface StringElement {
	type: 'String';
	name: string;
	minLength: number;
	maxLength: number;
	isAlpha?: boolean;
}

export default StringElement;
