using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace DotNetNinjaQuiz.gfx
{
    public class SoundService
    {
        Dictionary<SoundEffect, Uri> _effects;
        MediaPlayer _player;

        public SoundService()
        {
            _effects = new Dictionary<SoundEffect, Uri>();
            AddSound(SoundEffect.Applause, "applause-2.wav");
            AddSound(SoundEffect.Laughter, "crowd_laugh_1.wav");
            AddSound(SoundEffect.NewQuestion, "sound106.wav");
            AddSound(SoundEffect.ButtonPress, "sound63.wav");
            AddSound(SoundEffect.QuestionCommitted, "sound101.wav");

            _player = new MediaPlayer();
        }

        private void AddSound(SoundEffect effect, string filename)
        {
            _effects.Add(effect, new Uri(String.Format("gfx/sounds/{0}", filename), UriKind.Relative));
        }

        public void PlayEffect(SoundEffect effect)
        {
            _player.Open(_effects[effect]);
            _player.Play();
        }
    }
}
