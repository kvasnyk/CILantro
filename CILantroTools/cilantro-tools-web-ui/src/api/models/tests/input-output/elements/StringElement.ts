interface StringElement {
	type: 'String';
	name: string;
	minLength: number;
	maxLength: number;
	hasBigLetters: boolean;
	hasSmallLetters: boolean;
	hasDigits: boolean;
}

export default StringElement;
