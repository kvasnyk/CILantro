interface IntElement {
	type: 'Byte' | 'Short' | 'Int' | 'Long' | 'Sbyte' | 'Uint' | 'Ulong' | 'Ushort';
	name: string;
	minValue: number;
	maxValue: number;
	description?: string;
	excludeZero?: boolean;
}

export default IntElement;
