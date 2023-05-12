import 'package:equatable/equatable.dart';

class Home extends Equatable {
  final String author;
  final String title;
  final String description;
  final String imageUrl;
  final DateTime dateTime;
  final String tag;
  const Home({
    required this.author,
    required this.title,
    required this.description,
    required this.imageUrl,
    required this.dateTime,
    required this.tag,
  });
  @override
  List<Object?> get props =>
      [author, title, description, imageUrl, dateTime, tag];
}
