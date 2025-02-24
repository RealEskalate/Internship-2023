import 'package:equatable/equatable.dart';

class Issue extends Equatable {
  final String writer;
  final String description;
  final String title;

  Issue({required this.writer, required this.description, required this.title});

  @override
  List<Object?> get props => [writer, description, title];

  factory Issue.fromJson(Map<String, dynamic> json) {
    return Issue(
      writer: json['writer'],
      description: json['description'],
      title: json['title'],
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'writer': writer,
      'description': description,
      'title': title,
    };
  }
}
