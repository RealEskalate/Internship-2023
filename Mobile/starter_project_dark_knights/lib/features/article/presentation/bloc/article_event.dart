part of 'article_bloc.dart';

abstract class ArticleEvent extends Equatable {
  @override
  List<Object?> get props => [];
}

class GetArticlesEvent extends ArticleEvent {}

class DeleteArticleEvent extends ArticleEvent {
  final String articleId;

  DeleteArticleEvent({required this.articleId});
  @override
  List<Object?> get props => [articleId];
}

class UpdateArticleEvent extends ArticleEvent {
  final String articleId;
  final ArticleModel article;

  UpdateArticleEvent({required this.articleId, required this.article});

  List<Object?> get props => [articleId, article];
}

class PostArticleEvent extends ArticleEvent {
  final ArticleModel article;
  PostArticleEvent({required this.article});

  List<Object?> get props => [article];
}

class GetArticleByIdEvent extends ArticleEvent {
  final String articleId;
  GetArticleByIdEvent({required this.articleId});

  List<Object?> get props => [articleId];
}

class GetArticleByUserIdEvent extends ArticleEvent {
  final String userId;
  GetArticleByUserIdEvent({required this.userId});

  List<Object?> get props => [userId];
}
