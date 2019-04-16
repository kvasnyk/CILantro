interface FloatElement {
	type: 'Float' | 'Double' | 'Decimal';
	name: string;
	minValue: number;
	maxValue: number;
	description?: string;
	excludeZero?: boolean;
}

export default FloatElement;
