interface FloatElement {
	type: 'Float' | 'Double' | 'Decimal';
	name: string;
	minValue: number;
	maxValue: number;
}

export default FloatElement;
