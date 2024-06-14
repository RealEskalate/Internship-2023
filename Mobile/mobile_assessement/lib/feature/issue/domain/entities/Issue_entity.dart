import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';
import '../../../../core/errors/failures.dart';

class Issue extends Equatable {
  final String userName;
  final String postedDate;
  final String description;
  final String title;
  final String id;

  Issue(
      {required this.userName,
      required this.postedDate,
      required this.title,
      required this. description,
      required this.id
      }
      )
      : super();

  @override
  List<Object?> get props => [
        userName,
        postedDate,
        description,
        id,
        title,
      ];
}
