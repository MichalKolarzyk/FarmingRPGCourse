using System;
using System.Collections;
using UnityEngine;

public class UIFadeImageController
{
  readonly CurrentSceneContext model;
  readonly UIFadeImageView view;
  public UIFadeImageController(UIFadeImageView view, CurrentSceneContext model)
  {
    this.view = view;
    this.model = model;
  }

  public void Enable()
  {
    model.OnBeforeSceneChange += OnBeforeSceneChangeHandler;
    model.OnAfterSceneChange += OnAftereSceneChangeHandler;
  }

  private IEnumerator OnBeforeSceneChangeHandler(OnSceneChange eventArg)
  {
    view.SetColor(Color.black);
    yield return new WaitForSeconds(1);
  }

  private IEnumerator OnAftereSceneChangeHandler(OnSceneChange eventArg)
  {
    yield return null;
    view.SetColor(new Color(0, 0, 0, 0));
  }



  public void Disable()
  {
    model.OnBeforeSceneChange -= OnBeforeSceneChangeHandler;
    model.OnAfterSceneChange -= OnAftereSceneChangeHandler;
  }
}