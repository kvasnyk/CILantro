interface FloatElement {
	type: 'Float' | 'Double' | 'Decimal';
	name: string;
	minValue: number;
	maxValue: number;
	description?: string;
}

export default FloatElement;
