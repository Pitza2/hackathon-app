// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'IssueData.dart';

// **************************************************************************
// TypeAdapterGenerator
// **************************************************************************

class IssueDataAdapter extends TypeAdapter<IssueData> {
  @override
  final int typeId = 0;

  @override
  IssueData read(BinaryReader reader) {
    final numOfFields = reader.readByte();
    final fields = <int, dynamic>{
      for (int i = 0; i < numOfFields; i++) reader.readByte(): reader.read(),
    };
    return IssueData(
      fields[0] as String,
      fields[1] as String,
      fields[2] as String,
    );
  }

  @override
  void write(BinaryWriter writer, IssueData obj) {
    writer
      ..writeByte(3)
      ..writeByte(0)
      ..write(obj.issueTitle)
      ..writeByte(1)
      ..write(obj.issueText)
      ..writeByte(2)
      ..write(obj.specialization);
  }

  @override
  int get hashCode => typeId.hashCode;

  @override
  bool operator ==(Object other) =>
      identical(this, other) ||
      other is IssueDataAdapter &&
          runtimeType == other.runtimeType &&
          typeId == other.typeId;
}
