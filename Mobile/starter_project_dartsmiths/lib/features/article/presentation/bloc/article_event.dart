part of 'article_bloc.dart';

abstract class ArticleEvent extends Equatable {
  const ArticleEvent();

  @override
  List<Object> get props => [];
}


class GetArticleEvent extends ArticleEvent {
  String id;
  GetArticleEvent({required this.id});

  @override
  List<Object> get props => [id];
}


class UpdateArticleEvent extends ArticleEvent {

  final Article article;
  UpdateArticleEvent({required this.article});

  @override
  List<Object> get props => [article];
}


class PostArticleEvent extends ArticleEvent {

  final Article article;
  PostArticleEvent({required this.article});

  @override
  List<Object> get props => [article];
}