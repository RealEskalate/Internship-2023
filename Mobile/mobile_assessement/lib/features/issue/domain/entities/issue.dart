import 'package:equatable/equatable.dart';

class Issue extends Equatable {
  final String name;
  final String description;
  final String title;

  Issue({required this.name, required this.description, required this.title});

  @override
  List<Object?> get props => [name, description, title];
}

