import 'package:bloc/bloc.dart';
import 'package:dartsmiths/features/article/domain/entities/article.dart';
import 'package:dartsmiths/features/article/domain/repositories/article_repository.dart';
import 'package:dartsmiths/features/article/domain/usecases/get_article.dart';
import 'package:dartsmiths/features/article/domain/usecases/post_article.dart';
import 'package:dartsmiths/features/article/domain/usecases/update_article.dart';
import 'package:dartz/dartz.dart';
import 'package:equatable/equatable.dart';
import 'package:flutter/material.dart';

part 'article_event.dart';
part 'article_state.dart';

class ArticleBloc extends Bloc<ArticleEvent, ArticleState> {
  final PostArticle postArticle;
  final UpdateArticle updateArticle;
  final GetArticle getArticle;

  ArticleBloc(
      {required this.postArticle,
      required this.updateArticle,
      required this.getArticle})
      : super(ArticleInitial()) {
    on<ArticleEvent>((event, emit) {
      emit(ArticleLoading());
    });

    on<PostArticleEvent>((event, emit) async {
      try {
        emit(ArticleLoading());
        final article = await postArticle(event.article);
        emit(ArticleSuccess(article: article as Article));
      } catch (e) {
        emit(ArticleFailure(error: e as Error));
      }
    });

    on<UpdateArticleEvent>((event, emit) async {
      try {
        emit(ArticleLoading());
        final article = await updateArticle(event.article);
        emit(ArticleSuccess(article: article as Article));
      } catch (e) {
        emit(ArticleFailure(error: e as Error));
      }
    });

    on<GetArticleEvent>((event, emit) async {
      try {
        emit(ArticleLoading());
        Future.delayed(Duration(seconds: 3), () {
          // Perform the task after the delay
          print('Delayed task executed!');
        });
        // final article = await getArticle(event.id);
        Article article_ = Article(
            id: '1234',
            title: 'title',
            content: 'content',
            subTitle: "tamtmtmt",
            tags: ["nana", "dgfeufhe"],
            authorId: "12334"
            );

        print("objecn\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nt");
        emit(ArticleSuccess(article: article_));
      } catch (e) {
        emit(ArticleFailure(error: e as Error));
      }
    });
  }
}
