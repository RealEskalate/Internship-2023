import 'package:equatable/equatable.dart';

class Article extends Equatable {
  final String title;
  final String subtitle;
  final String content;
  final DateTime date;
  final int likesCount;
  final List<String> tags;

  const Article({
    required this.title,
    required this.subtitle,
    required this.content,
    required this.date,
    required this.likesCount,
    required this.tags,
  });

  @override
  List<Object?> get props => [title, subtitle, content, date, likesCount, tags];
}