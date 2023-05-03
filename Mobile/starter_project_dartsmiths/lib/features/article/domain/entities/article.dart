import 'package:equatable/equatable.dart';
import 'package:meta/meta.dart';

class Article extends Equatable {
  final String title;
  final String subtitle;
  final List<String> tag;
  final String message;
  final String image;

  Article({
    required this.title,
    required this.subtitle,
    required this.tag,
    required this.message,
    required this.image,
  });

  @override
  List<Object> get props => [title, subtitle, tag, message, image];
}
