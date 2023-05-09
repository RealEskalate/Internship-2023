import 'package:flutter/material.dart';

import '../widgets/article_like_button.dart';
import '../widgets/article_post.dart';
import '../widgets/header.dart';
import '../widgets/header_icons.dart';

class ArticleReadingPage extends StatefulWidget {
  const ArticleReadingPage({super.key});

  @override
  State<ArticleReadingPage> createState() => _ArticleReadingPageState();
}

class _ArticleReadingPageState extends State<ArticleReadingPage> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: Column(
          children: [
            const HeaderIconButtons(),
            Expanded(
              child: SingleChildScrollView(
                child: Column(
                  children: const [Header(), ArticlePost()],
                ),
              ),
            ),
          ],
        ),
        floatingActionButton: const ArticleLikeButton());
  }
}
