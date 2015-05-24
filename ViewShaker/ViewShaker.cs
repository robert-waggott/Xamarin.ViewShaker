using System;
using System.Collections.Generic;

using CoreAnimation;
using Foundation;
using UIKit;

namespace ViewShaker
{
	public class ViewShaker : CAAnimationDelegate
	{
		public event EventHandler<EventArgs> AnimationCompleted;

		private const string ANIMATION_KEY = "kAFViewShakerAnimationKey";

		private readonly IList<UIView> views;

		private int completedAnimations = 0;

		public ViewShaker(UIView view)
			: this(new List<UIView> { view })
		{
		}

		public ViewShaker(IList<UIView> views)
		{
			this.views = views;
		}

		public void Shake(double duration = 0.5)
		{
			var animation = CAKeyFrameAnimation.GetFromKeyPath("transform.translation.x");

			animation.Delegate = this;
			animation.Duration = duration;
			animation.Values = new NSObject[] 
			{  
				NSNumber.FromFloat(0),
				NSNumber.FromFloat(10),
				NSNumber.FromFloat(-8),
				NSNumber.FromFloat(8),
				NSNumber.FromFloat(-5),
				NSNumber.FromFloat(5),
				NSNumber.FromFloat(0)
			};
			animation.KeyTimes = new NSNumber[] 
			{ 
				new NSNumber(0),
				new NSNumber(0.225),
				new NSNumber(0.425),
				new NSNumber(0.6),
				new NSNumber(0.75),
				new NSNumber(0.875),
				new NSNumber(1)
			};
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);

			foreach (var view in this.views)
			{
				view.Layer.AddAnimation(animation, ANIMATION_KEY);
			}
		}

		public override void AnimationStopped(CAAnimation anim, bool finished)
		{
			completedAnimations += 1;

			if (completedAnimations == this.views.Count)
			{
				this.completedAnimations = 0;

				if (this.AnimationCompleted != null)
				{
					this.AnimationCompleted(this, EventArgs.Empty);
				}
			}
		}
	}
}