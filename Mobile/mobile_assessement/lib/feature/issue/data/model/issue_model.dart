import 'dart:convert';
import 'package:equatable/equatable.dart';

class IssueModel extends Equatable {
  final String userName;
  final String postedDate;
  final String description;
  final String title;
  final String id;

  IssueModel({
    required this.userName,
    required this.postedDate,
    required this.title,
    required this.description,
    required this.id,
  });

  factory IssueModel.fromJson(Map<String, dynamic> json) {
    return IssueModel(
      userName: json['userName'] as String,
      postedDate: json['postedDate'] as String,
      title: json['title'] as String,
      description: json['description'] as String,
      id: json['id'] as String,
    );
  }

  Map<String, dynamic> toJson() {
    return {
      'userName': userName,
      'postedDate': postedDate,
      'title': title,
      'description': description,
      'id': id,
    };
  }

  @override
  List<Object?> get props => [userName, postedDate, description, id, title];
}
